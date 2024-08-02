package com.example.projectp11;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.SeekBar;
import android.widget.TextView;

import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;

public class MainActivity extends AppCompatActivity {

    private DatabaseReference reference = FirebaseDatabase.getInstance().getReference();


    TextView textView;
    TextView textView2;
    TextView textView3;
    TextView textView4;
    SeekBar seekBar;
    SeekBar seekBar2;
    SeekBar seekBar3;
    SeekBar seekBar4;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        textView = (TextView) findViewById(R.id.textView2);
        seekBar = (SeekBar) findViewById(R.id.seekBar);
        textView2 = (TextView) findViewById(R.id.textView4);
        seekBar2 = (SeekBar) findViewById(R.id.seekBar2);
        textView3 = (TextView) findViewById(R.id.textView6);
        seekBar3 = (SeekBar) findViewById(R.id.seekBar3);
        textView4 = (TextView) findViewById(R.id.textView8);
        seekBar4 = (SeekBar) findViewById(R.id.seekBar4);


        seekBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                textView.setText(String.valueOf(progress));
                reference.child("FMM").child("M3A").child("Sensores1").child("LDR").setValue(String.valueOf(progress));
            }
            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {}
            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {}
        });

        seekBar2.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress2, boolean fromUser) {
                textView2.setText(String.valueOf(progress2));
                reference.child("FMM").child("M3A").child("Sensores1").child("LM35").setValue(String.valueOf(progress2));
            }
            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {}
            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {}
        });

        seekBar3.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress3, boolean fromUser) {
                textView3.setText(String.valueOf(progress3));
                reference.child("FMM").child("M3A").child("Sensores2").child("Distancia").setValue(String.valueOf(progress3));
            }
            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {}
            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {}
        });

        seekBar4.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress4, boolean fromUser) {
                textView4.setText(String.valueOf(progress4));
                reference.child("FMM").child("M3A").child("Sensores2").child("Velocidade").setValue(String.valueOf(progress4));
            }
            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {}
            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {}
        });
    }
}