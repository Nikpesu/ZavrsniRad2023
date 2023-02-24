void clearAllLayers();
void drawBroj(int x, int y, int znak, int scaling, uint8_t *boje);
void drawClock(int x, int y, int scaling, uint8_t *boje);
void drawLetter(int x, int y, char znak, uint8_t *boje);
void typeText(int x, int y, String text, uint8_t *boje);
void drawDaytimeLine(int x1, int y1, int x2, int y2, float sat, int povecanje);
void typeTextNoNl(int x, int y, String text, uint8_t *boje);
void drawLetterNoNl(int x, int y, char znak, uint8_t *boje);
void refreshTime();
void swapAllLayerBuffers();
void clearAllLayerBuffers();
bool gumbPress(uint8_t ulaz);
void gumbiSense();
void displayDraw();

void drawDaytimeLine(int x1, int y1, int x2, int y2, float sat, int povecanje=60)
{
      if (vrijemeZalaska<vrijemeIzlaska)vrijemeZalaska+=24;
      int satx=0;
      for(int i=x1; i<x2; i++)
      {
        satx=i/64.0*24+sat;
        if(satx>=24) satx-=24;
        if(satx>vrijemeIzlaska and satx<vrijemeZalaska)
        {
          if(dan!=255)
          {
            dan+=(dan+povecanje>255?255%povecanje-dan%povecanje:povecanje);
            noc-=(noc-povecanje<0?255%povecanje-dan%povecanje:povecanje);
          }
        }
        else
        {
          if(noc!=255)
          {
            noc+=(noc+povecanje>255?255%povecanje-noc%povecanje:povecanje);
            dan-=(dan-povecanje<0?255%povecanje-dan%povecanje:povecanje);
          }
        }

        backgroundLayer.drawFastVLine(i, y1, y2,{dan,dan,noc});
      }
}

void drawLetter(int x, int y, char znak, uint8_t *boje)
{
  int trenutnoSlovo=((int)znak)-32;
  for(int j=0 ;j<5; j++)
  {
    int pomBr=0;
      for(int i=trenutnoSlovo*3; i<3+trenutnoSlovo*3; i++)        
      {
          int brojkeX=i;
          int ypos=y+j;
          int xpos=x+pomBr++;
          backgroundLayer.drawPixel(xpos, ypos, {*(boje)*miniLetters[brojkeX][j] , *(boje+1)*miniLetters[brojkeX][j], *(boje+2)*miniLetters[brojkeX][j]});
      }
  }
}
void typeText(int x, int y, String text, uint8_t *boje)
{
  int xpoc=x;
  for(int i=0; i<text.length(); i++)
  {
    if((char)text[i]=='\n'){y=y+6; x=xpoc; i+=1; if(i>=text.length()) return;}
    
    drawLetter(x, y, (char)text[i], boje);
    if(x+6<kMatrixWidth) x+=4; else if(y+11<kMatrixHeight) {y=y+6; x=xpoc;} else return;
    
  } 
}

void drawLetterNoNl(int x, int y, char znak, uint8_t *boje)
{
  int trenutnoSlovo=((int)znak)-32;
  for(int j=0 ;j<5; j++)
  {
    int pomBr=0;
      for(int i=trenutnoSlovo*3; i<3+trenutnoSlovo*3; i++)        
      {
          int brojkeX=i;
          int ypos=y+j;
          int xpos=x+pomBr++;
          if(x>=0 and x<=kMatrixWidth)backgroundLayer.drawPixel(xpos, ypos, {*(boje)*miniLetters[brojkeX][j] , *(boje+1)*miniLetters[brojkeX][j], *(boje+2)*miniLetters[brojkeX][j]});
      }
  }
}
void typeTextNoNl(int x, int y, String text, uint8_t *boje)
{
  int xpoc=x;
  for(int i=0; i<text.length(); i++)
  {
    drawLetterNoNl(x, y, (char)text[i], boje);
    x+=4;
  } 
}
void drawBroj(int x, int y, int znak, int scaling, uint8_t *boje)
{
    for(int j=0; j<10; j++)
    {
      int pomBr=0;
        for(int i=znak*5; i<5+znak*5; i++)        
        {
            int brojkeX=i;
            int ypos=y+j*scaling;
            int xpos=x+pomBr;
            pomBr+=scaling;
            for(int i1=0; i1<scaling; i1++)for(int j1=0; j1<scaling; j1++) 
              backgroundLayer.drawPixel(xpos+i1, ypos+j1, {*(boje)*brojke[brojkeX][j] , *(boje+1)*brojke[brojkeX][j], *(boje+2)*brojke[brojkeX][j]});
        }
    }
}

void drawClock(int x, int y, int scaling, uint8_t *boje)
{    
    
    String vrijemeIspisa=(String)((sat-sat%10)/10)+ (String)(sat%10)+(tocke ? ":":" ")+(String)((minuta-minuta%10)/10)+ (String)(minuta%10);
    

    int tockaMinus=0;
    for(int i=0;i<vrijemeIspisa.length();i++)
      if(vrijemeIspisa[i]==':' and tocke) 
        {drawBroj((x+i*6*scaling+tockaMinus), y, 11, scaling, boje); tockaMinus-=scaling;} 
      else 
      if(vrijemeIspisa[i]!=' ' and vrijemeIspisa[i]!=':') 
        drawBroj((x+i*6*scaling+tockaMinus), y, ((String)vrijemeIspisa[i]).toInt(), scaling, boje); 
      else 
        tockaMinus-=scaling;
//Serial.println("!da!");
//Serial.println(tocke);
}


void clearAllLayers() {
  backgroundLayer.fillScreen((rgb24)BLACK);
  backgroundLayer.swapBuffers();
  indexedLayerZ1.fillScreen(BLACK);
  indexedLayerZ1.swapBuffers();
  indexedLayerZ2.fillScreen(BLACK);
  indexedLayerZ2.swapBuffers();
}
void clearAllLayerBuffers() {
  backgroundLayer.fillScreen((rgb24)BLACK);
  indexedLayerZ1.fillScreen(BLACK);
  indexedLayerZ2.fillScreen(BLACK);
}
void swapAllLayerBuffers() {
  backgroundLayer.swapBuffers();
  indexedLayerZ1.swapBuffers();
  indexedLayerZ2.swapBuffers();
}

void refreshTime()
{
  
  DateTime now = rtc.now();
  sat=now.hour(); 
  minuta=now.minute(); 
  sekunda=now.second();
  
  tocke=!tocke;
}

bool gumbPress(uint8_t ulaz)
{
  adc0.setMultiplexer(ulaz);
  if(adc0.getMilliVolts(false)>1000)
    return true;
  else 
    return false;
}

void gumbiSense()
{
  if(++zadnje_stisnuto>2) //svakih cca 0.5s
  {
    gumbStanje=0;
  }
  bool g0=gumbPress(ADS1115_MUX_P0_NG);
  bool g1=gumbPress(ADS1115_MUX_P1_NG);
  bool g2=gumbPress(ADS1115_MUX_P2_NG);
  bool g3=gumbPress(ADS1115_MUX_P3_NG);
  bool jelStisnuto=(g0 or g1 or g2 or g3);
  if(gumbStanje==0 and jelStisnuto)
  {
    gumbStanje=1;
    if(g0)
    {
      stateID+=1;
      if(stateID>4) stateID=1;
      saveStanje=1;
    }
    else if(g1)
    {
      if (svjetlina+50>255) svjetlina=50; else svjetlina+=50;
      matrix.setBrightness(svjetlina);
      saveStanje=1;
    }
    else if(g2)
    {
      uint8_t r= boja1[0],g= boja1[1],b= boja1[2];
      boja1[0]=boja2[0];    boja1[1]=boja2[1];    boja1[2]=boja2[2];
      boja2[0]=boja3[0];    boja2[1]=boja3[1];    boja2[2]=boja3[2];
      boja3[0]=r;           boja3[1]=g;           boja3[2]=b;
      saveStanje=1;
    } 
    else if(g3)
    {
      clearAllLayers();
      indexedLayerZ1.drawString(0,0,1,"Wi-Fi detalji");
      if(WiFi.status() == WL_CONNECTED) 
        typeText(0,7,(String)("SSID:\n"+(String)myWIFI.getNameSSID()+"\nIP-WiFi:\n"+myWIFI.getDevStatusIP().substring(9)),&boja2[0]);
      else 
        typeText(0,7,(String)("SSID:\n"+APssid+"\nIP-HOTSPOT:\n192.168.4.1"),&boja2[0]);
      swapAllLayerBuffers();
      delay(5000);
    }
    zadnje_stisnuto=0;
  }
  if(saveStanje==1)
    if(zadnje_stisnuto>50 ) //nakon cca 10s
    {
      saveStanje=0;
      
      saveConfig();
    }
}


void displayDraw()
{
  matrix.setBrightness(svjetlina);
  clearAllLayerBuffers();
  if(stateID==1)
  {
    statusTrenutno= (String)tempCurr + "*C-temp.   "+ (String)humCurr+"%RH-vlaga   " + (String)windCurr+"m/s-vjetar   "+ (String)pressCurr+"hPa-tlak   " +(String) visibilityCurr+"m-vidljivost   "+ (String)skyCurr + "%-oblaka   ";
    drawClock(4,1,2, &boja1[0]);
    drawDaytimeLine(0,22,64,23,(sat+minuta/60.0),50);
    typeTextNoNl(--statusTrenutniPomak,25,statusTrenutno,&boja2[0]);
    // Serial.println(4*da.length());
    //Serial.println(xda>4*da.length());
    // Serial.println(xda);
    if(-(int)statusTrenutniPomak>(int)(4*statusTrenutno.length())) {statusTrenutniPomak=kMatrixWidth;}
      // Serial.println(xda);
  }
  else if(stateID==2)
  {
    drawClock(4,1,2, &boja1[0]);
    drawDaytimeLine(0,22,64,23,(sat+minuta/60.0),50);
    String datum=(String)rtc.now().day()+"."+(String)rtc.now().month()+"."+(String)rtc.now().year()+".";
    typeTextNoNl((16-datum.length())/2.0*4,25, datum,&boja2[0]);

  }
  else if(stateID==3)
  {
    drawClock(4,1,2, &boja1[0]);
    String datum=(String)rtc.now().day()+"."+(String)rtc.now().month()+"."+(String)rtc.now().year()+".";
    typeTextNoNl((16-datum.length())/2.0*4,25, datum,&boja2[0]);
  }
  else if(stateID==4)
  {
    statusTrenutno= (String)tempCurr + "*C-temp.   "+ (String)humCurr+"%RH-vlaga   " + (String)windCurr+"m/s-vjetar   "+ (String)pressCurr+"hPa-tlak   " +(String) visibilityCurr+"m-vidljivost   "+ (String)skyCurr + "%-oblaka   ";
    drawClock(4,1,2, &boja1[0]);
    drawDaytimeLine(0,22,64,23,(sat+minuta/60.0),50);
    typeTextNoNl(--statusTrenutniPomak,25,statusTrenutno,&boja2[0]);
    // Serial.println(4*da.length());
    //Serial.println(xda>4*da.length());
    // Serial.println(xda);
    if(-(int)statusTrenutniPomak>(int)(4*statusTrenutno.length())) {statusTrenutniPomak=kMatrixWidth;}
      // Serial.println(xda);
    if(WiFi.status() == WL_CONNECTED) 
      backgroundLayer.drawFastHLine(15,48,31,{0,32,64});
    else 
      backgroundLayer.drawFastHLine(15,48,31,{64,32,0});
  }
  swapAllLayerBuffers();
}