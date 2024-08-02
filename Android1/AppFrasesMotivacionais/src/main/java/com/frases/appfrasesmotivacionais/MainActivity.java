package com.frases.appfrasesmotivacionais;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.Random;

public class MainActivity extends AppCompatActivity {

    private TextView frases;
    private Button gerarFrases;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        frases = findViewById(R.id.textView);
        gerarFrases = findViewById(R.id.button3);

        gerarFrases.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String[] frasesMotivacionais = {
                        "Lembre-se do seu passado com carinho. Afinal, é por causa dele que você está aqui hoje!",
                        "É importante agradecer pelo hoje sem nunca desistir do amanhã!",
                        "Desejar algo maior pra sua vida não significa que você está insatisfeito com o que tem.",
                        "Se expressarmos gratidão pelo que temos, teremos mais por que expressar gratidão.",
                        "Quem cultiva gratidão é capaz de realizar sonhos que parecem inalcançáveis!"
                };

                Random random = new Random();
                int numerosAleatorios = random.nextInt(frasesMotivacionais.length);

                frases.setText(frasesMotivacionais[numerosAleatorios]);
            }
        });



    }
}