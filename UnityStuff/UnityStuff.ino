const int playerOne = A0;
const int playerTwo = A1;

int incomingByte;

void setup() {
  // put your setup code here, to run once:
 Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  
  if(Serial.available() > 0){
    
    incomingByte = Serial.read();

    if(incomingByte == 'P'){
      SendPositions();
    }
    
  }
  
}

void SendPositions()
{
  
  int position1 = analogRead(playerOne);
  int position2 = analogRead(playerTwo);

  Serial.print(position1);
  Serial.print('-');
  Serial.println(position2);
  
}

