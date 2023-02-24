
void httpSetup();
void updateWeather();
void refreshAPIs();
void updateTime();
void recconectWifi();

void recconectWifi()
{
  if(WiFi.isConnected()==0) 
    myWIFI.reconectWIFI();
}

 //timezonedb.com api
void updateTime()
{
  if(WiFi.status()== WL_CONNECTED)
  {
    HTTPClient http;
    String timeApiPath="http://api.timezonedb.com/v2.1/get-time-zone?key="+timeApiKey+"&format=xml&by=position&lat="+(String)lat+"&lng="+(String)lng;
    http.begin(timeApiPath.c_str());
    int httpResponseCode = http.GET();
    if (httpResponseCode>0) {
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);
      String payload = http.getString();
      int brojda1=payload.indexOf("<timestamp>")+strlen("<timestamp>");
      int brojda2=payload.indexOf("</timestamp>");
      //Serial.println(payload);
      uint64_t vrijemeSad=strtoul(payload.substring(brojda1,brojda2).c_str(),nullptr,0);
      Serial.println(vrijemeSad);
      rtc.adjust(vrijemeSad);
    } 
    else {
      Serial.print("Error code: ");
      Serial.println(httpResponseCode);
    }
    http.end();
  }
  else {
    Serial.println("WiFi Disconnected");
  }
}

//vrijemeZalaska vrijemeIzlaska
void updateWeather()
{
  if(WiFi.status()== WL_CONNECTED)
  {
    HTTPClient http;
    String timeApiPath="https://api.openweathermap.org/data/2.5/weather?lat="+(String)lat+"&lon="+(String)lng+"&appid="+weatherApiKey+"&units=metric";
    http.begin(timeApiPath.c_str());
    int httpResponseCode = http.GET();
    if (httpResponseCode>0) {
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);
      String payload = http.getString();
      DynamicJsonDocument jsonDoc(5096);
      DeserializationError error = deserializeJson(jsonDoc, payload);
      Serial.println(payload);
      if (error) {
        Serial.print(F("updateWeather() deserializeJson() failed with code "));
        Serial.println(error.c_str());
      }
      else
      {
        JsonObject root = jsonDoc.as<JsonObject>();   
        tempCurr=(float)root["main"]["temp"];
        humCurr=(float)root["main"]["humidity"];
        vrijemeIzlaska=(((int)root["sys"]["sunrise"]+(int)root["timezone"])%86400/60.0/60);
        vrijemeZalaska=(((int)root["sys"]["sunset"]+(int)root["timezone"])%86400/60.0/60);
        windCurr=(float)root["wind"]["speed"];
        pressCurr=(int)root["main"]["pressure"];
        visibilityCurr=(int)root["visibility"];
        skyCurr=(int)root["clouds"]["all"];
      }
    } 
    else {
      Serial.print("Error code: ");
      Serial.println(httpResponseCode);
    }
    http.end();
  }
  else {
    Serial.println("WiFi Disconnected");
  }
}      
void notFound(AsyncWebServerRequest *request) {
    request->send(404, "text/html", "<!doctype html><html><head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\" /></head> <body>Stranica nije pronađena!<br> <a href=\"/\"> <input id=\"posaljitelj\" type=\"submit\" value=\"Početna stranica!\" style=\"height: 4em;  width: 10em;\"></a></body></html>");
}
void httpSetup()
{

  HTTP.on("/", HTTP_GET, [](AsyncWebServerRequest *request){
        request->send(SPIFFS, "/index.html", "text/html");
  });
  HTTP.on("/reset", HTTP_GET, [](AsyncWebServerRequest *request){
    request->send(200,"text/html", "<!doctype html> <html><script>window.location.replace(\"/\");</script></html>");
    delay(1500);
    ESP.restart();
  });

  HTTP.on("/get", HTTP_GET, [] (AsyncWebServerRequest *request) {
    String tmp;
    bool changedAny=0;
    if (request->hasParam("latitude") && request->getParam("latitudechange")->value()=="1") {
      lat=atof((request->getParam("latitude")->value()).c_str());
      changedAny=1;
    }
    if (request->hasParam("longitude") && request->getParam("longitudechange")->value()=="1") {
      lng=atof((request->getParam("longitude")->value()).c_str());
      changedAny=1;
    }
    if (request->hasParam("boja1") && request->getParam("boja1change")->value()=="1") {
      tmp=(request->getParam("boja1")->value());
      tmp = tmp.substring(1, tmp.length() );
      int r,g,b;
      sscanf(tmp.c_str(), "%02x%02x%02x", &r, &g, &b);
      boja1[0]=r;boja1[1]=g;boja1[2]=b;
      changedAny=1;
    }
    if (request->hasParam("boja2") && request->getParam("boja2change")->value()=="1") {
      tmp=request->getParam("boja2")->value();
      tmp = tmp.substring(1, tmp.length() );
      int r,g,b;
      sscanf(tmp.c_str(), "%02x%02x%02x", &r, &g, &b);
      boja2[0]=r;boja2[1]=g;boja2[2]=b;
      changedAny=1;
    }
    if (request->hasParam("boja3") && request->getParam("boja3change")->value()=="1") {
      tmp=request->getParam("boja3")->value();
      tmp = tmp.substring(1, tmp.length() );
      int r,g,b;
      sscanf(tmp.c_str(), "%02x%02x%02x", &r, &g, &b);
      boja3[0]=r;boja3[1]=g;boja3[2]=b;
      changedAny=1;
    }
    if (request->hasParam("SSID") && request->getParam("SSIDchange")->value()=="1")  {
      SSID=request->getParam("SSID")->value();
      changedAny=1;
    }
    if (request->hasParam("PASSWORD") && request->getParam("PASSWORDchange")->value()=="1") {
      PASS=request->getParam("PASSWORD")->value();
      changedAny=1;
    }
    if (request->hasParam("APSSID") && request->getParam("APSSIDchange")->value()=="1") {
      APssid=request->getParam("APSSID")->value();
      changedAny=1;
    }
    if (request->hasParam("APPASSWORD") && request->getParam("APPASSWORDchange")->value()=="1") {
      APpass=request->getParam("APPASSWORD")->value();
      changedAny=1;

    }
    if (request->hasParam("timezonedb") && request->getParam("timezonedbchange")->value()=="1") {
      timeApiKey=request->getParam("timezonedb")->value();
      changedAny=1;
    }
    if (request->hasParam("openweathermap") && request->getParam("openweathermapchange")->value()=="1") {
      weatherApiKey=request->getParam("openweathermap")->value();
      changedAny=1;
    }
    if (request->hasParam("mod") && request->getParam("modchange")->value()=="1") {
      stateID=(request->getParam("mod")->value()).toInt();
      changedAny=1;
    }
    if(changedAny) 
    {
      saveConfig();
      refreshAPIs();
      myWIFI.setConfigWIFI(SSID.c_str(), PASS.c_str(), APssid.c_str(), APssid.c_str(), APpass.c_str()); 
    }
    tmp="<!doctype html><head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\" /></head>";
    tmp+="<style>input[type=button]{width: 75%; height: 1.6em;}";
    tmp+="html{background-color: #DBDBDB;color: #376DAB;font-family: monospace;font-weight: bolder;}";
    tmp+="input:hover{transition: 0.5s; border: 2px brown solid;}input:focus{background-color: yellow;}";
    tmp+="input{font-size: 2vw;height: 1.5em;padding: auto;margin: 0.1em;color: #376DAB; font-family: monospace;background-color: #EE635240;border: 2px transparent solid;border-radius: 0.2em;font-weight: bolder;position: relative; width: 100%; transition: 0.5s;padding: 0px;height: 1.6em;}</style>";
    tmp+="<body><div style=\"display: flex; flex-direction: column;\"><h1>Poslano!</h1> <br> <a href=\"/\"> <input id=\"posaljitelj\" type=\"submit\" value=\"Vrati se nazad!\" style=\"height: 3em;  width: 99%;\"></a>";
    tmp+="<br><br><br> <form action=\"/reset\"> <a href=\"/\"> <input id=\"posaljitelj\" type=\"submit\" value=\"Restart Sata? (tako se wifi ponovo spaja na novi)\" style=\"height: 3em;  width: 99%;\"></a></form><br> </div><body>";

    //debug!
    if(1==0)
    {
    tmp+="<table>";
    tmp+="<tr><th>Varijabla</th><th>Vrijednost</th></tr>";
    tmp+="<tr><td>Geografska Širina</td><td>"+(String)lat+"</td></tr>";
    tmp+="<tr><td>Geografska Dužina</td><td>"+(String)lng+"</td></tr>";
    tmp+="<tr><td>Boja1</td><td>("+(String)boja1[0]+", "+(String)boja1[1]+", "+(String)boja1[2]+")</td></tr>";
    tmp+="<tr><td>Boja2</td><td>("+(String)boja2[0]+", "+(String)boja2[1]+", "+(String)boja2[2]+")</td></tr>";
    tmp+="<tr><td>Boja3</td><td>("+(String)boja3[0]+", "+(String)boja3[1]+", "+(String)boja3[2]+")</td></tr>";
    tmp+="<tr><td>WiFi SSID</td><td>"+(String)myWIFI.getNameSSID()+"</td></tr>";
    tmp+="<tr><td>WiFi Šifra</td><td>"+(String)myWIFI.getPassSSID()+"</td></tr>";
    tmp+="<tr><td>HotSpot SSID</td><td>"+(String)myWIFI.getNameAPSSID()+"</td></tr>";
    tmp+="<tr><td>HotSpot Šifra</td><td>"+(String)myWIFI.getPassAPSSID()+"</td></tr>";
    tmp+="<tr><td>Timezonedb Api</td><td>"+(String)timeApiKey+"</td></tr>";
    tmp+="<tr><td>openweathermap Api</td><td>"+(String)weatherApiKey+"</td></tr>";
    tmp+="<tr><td>ssdp</td><td>"+(String)myWIFI.getNameSSDP()+"</td></tr>";
    tmp+="</table>";
    }
    request->send(200,"text/html", tmp);
      
  });
  HTTP.onNotFound(notFound);
  HTTP.begin();
  
} 
void refreshAPIs()
{
    updateTime();
    updateWeather();
}