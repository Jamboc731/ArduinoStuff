const int playerOne = A0;
const int playerTwo = A1;

const int p1Led = 9;
const int p2Led = 5;

int oneVal;
int twoVal;
int p1Mil;
int p2Mil;
int curMil = 0;
int incomingByte;

bool p1Flash;
bool p2Flash;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(p1Led, OUTPUT);
  pinMode(p2Led, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  curMil = millis();
  
  
  if(Serial.available() > 0){
    incomingByte = Serial.read();
    if(incomingByte == 'p'){
      SendPositions();
    }
    if(incomingByte == '1'){
      digitalWrite(p1Led, HIGH);
      p1Flash = true;
      p1Mil = curMil;
    }
    if(incomingByte == '2'){
      digitalWrite(p2Led, HIGH);
      p2Flash = true;
      p2Mil = curMil;
    }
  }

  if(p1Flash){
    if(curMil >= p1Mil + 100){
      digitalWrite(p1Led, LOW);
      p1Flash = false;
    }
  }
  else{
    digitalWrite(p1Led, LOW);
  }
  
  if(p2Flash){
    if(curMil >= p2Mil + 100){
      digitalWrite(p2Led, LOW);
      p1Flash = false;
    }
  }
  else{
    digitalWrite(p2Led, LOW);
  }
  
}

void SendPositions(){
  oneVal = analogRead(playerOne);
  twoVal = analogRead(playerTwo);

  Serial.print(oneVal);
  Serial.print("-");
  Serial.println(twoVal);
}


