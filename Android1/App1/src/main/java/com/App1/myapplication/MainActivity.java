package com.App1.myapplication;

import android.app.ActivityOptions;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    private Button botao1;
    private EditText EditText1;
    private Toast toast;
    private Button botao2;

    public void go(View view) {
        Intent i = new Intent(this, Student.class);
        Bundle b = ActivityOptions.makeSceneTransitionAnimation(this).toBundle();

        startActivity(i, b);

    }

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


        botao1 = findViewById(R.id.button4);
        EditText1 = findViewById(R.id.editTextText);
        botao2 = findViewById(R.id.button5);

        botao1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                CharSequence text = EditText1.getText();
                int duration = Toast.LENGTH_SHORT;

                toast = Toast.makeText(MainActivity.this, text, duration);

                toast.show();
            }

        });

        botao2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                go(v);

            }
        });


    }
}