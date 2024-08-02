int A[] = {0, 0, 1};
int B[] = {0, 0, 1};
int C[] = {0, 0, 0, 0};

int qtd_A;
int qtd_B;
int qtd_C;

void setup() {
  Serial.begin(9600);
  qtd_A = sizeof(A)/sizeof(int);
  qtd_B = sizeof(B)/sizeof(int);
  qtd_C = sizeof(C)/sizeof(int);
}

void loop() {
  int soma;
  int i;
  
  for (int j = 0 ; j < 4 ; j++){
        i = 2 - j;
        soma = A[i] + B[i] + C[i];
        if ( soma == 3) {
          C[i] = 1;
          C[i - 1] = 1; 
          } else {
            if ( soma == 2 ) {
              C[i] = 0;
              C[i - 1] = 1;
              } else {
                if ( soma == 3) {
                  C[i] = 1;
                  } else {
                    C[i] = 0;
                    }
                }
            }
        
    }

  Serial.println(" ");

  for ( int j = 0; j <= qtd_C ; j++){
    Serial.print(C[j]);
    Serial.print(" ");
  }
  delay(1000);
}
