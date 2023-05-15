#include <Arduino.h>
#include "config.h"
#include "display.h"
#include "HTTP.h"
TaskHandle_t Task1;

void setup() {
  Wire.begin(I2C_SDA, I2C_SCL);
  adc0.setRate(7);
  if(!SPIFFS.begin(true)) { // Initialize SPIFFS
        Serial.println("An Error has occurred while mounting SPIFFS");
        return;
  } 
  Serial.begin(115200);
  Serial.println("JSON LOAD!");
  loadConfig();
  //for(int i=0; i<3; i++) boja1[i]=255;
  //for(int i=0; i<3; i++) boja2[i]=(i!=2?255:0);
  //for(int i=0; i<3; i++) boja3[i]=(i!=1?255:0);
  //saveConfig();
  matrix.addLayer(&backgroundLayer); 
  matrix.addLayer(&indexedLayerZ1); 
  matrix.addLayer(&indexedLayerZ2);
  matrix.begin();
  matrix.setBrightness(svjetlina);
  
  indexedLayerZ1.drawString(1,1,1,"Wi-Fi spajanje");
  indexedLayerZ1.drawString(1,26,1,(nName+"  "+nVersion).c_str());
  indexedLayerZ1.swapBuffers();
  
  rtc.begin();
  refreshTime();
  myWIFI.begin(SSID.c_str(), PASS.c_str(), APssid.c_str(), APssid.c_str(), APpass.c_str(), "192.168.4.1");
  if (WiFi.status() == WL_CONNECTED)  {
    //mySSDP.begin(SSDP_Name.c_str(), "000000001", nName.c_str(), nVersion.c_str(), "NikoPesut", "https://kikirikiserver.hopto.org:60001"); Serial.println(F("Start init SSDP"));
    Serial.println(F("Start SSDP"));   //Run SSDP
    //myESPTime.begin(timezone, isDayLightSaving, sNtpServerName, "pool.ntp.org", "time.nist.gov", true, true);
    clearAllLayers();
    indexedLayerZ1.drawString(0,0,1,"Wi-Fi spojen");
    typeText(0,7,(String)("SSID:\n"+(String)myWIFI.getNameSSID()+"\nIP-WiFi:\n"+myWIFI.getDevStatusIP().substring(9)),&boja2[0]);
    refreshAPIs();
  }  
  else
  {   
    clearAllLayers();  
    indexedLayerZ1.drawString(0,0,1,"Wi-Fi neuspjeh!");
    typeText(0,7,(String)("SSID:\n"+APssid+"\nIP-HOTSPOT:\n192.168.4.1"),&boja2[0]);
  }
  taskManager.scheduleFixedRate(300,refreshAPIs,TIME_SECONDS);//svakih 5 minuta
  taskManager.scheduleFixedRate(15,recconectWifi,TIME_SECONDS);//svakih 15 sekundi
  taskManager.scheduleFixedRate(1,refreshTime,TIME_SECONDS);//svaku 1 sekundi
  taskManager.scheduleFixedRate(100,displayDraw,TIME_MILLIS);//svakih 0.1 sekundi
  taskManager.scheduleFixedRate(99, gumbiSense, TIME_MILLIS);//svakih 0.1 sekundi
  swapAllLayerBuffers();
  httpSetup();
  delay(10000);
  clearAllLayers();
}
void loop(){
  taskManager.runLoop();
}
