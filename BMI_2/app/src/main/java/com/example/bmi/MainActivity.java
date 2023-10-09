package com.example.bmi;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    EditText height,weight;
    RadioButton rb_MALE, rb_Famale;
    Button btn_Find;
    TextView chisobmi, nhanxet;
    double chiso;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        height = findViewById(R.id.height);
        weight = findViewById(R.id.weight);
        rb_Famale = findViewById(R.id.rb_female);
        rb_MALE = findViewById(R.id.rb_MALE);
        btn_Find = findViewById(R.id.btn_find);
        chisobmi = findViewById(R.id.chisobmi);
        nhanxet = findViewById(R.id.nhanxet);

        btn_Find.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                double canNang = Double.parseDouble(weight.getText().toString());
                double chieuCao = Double.parseDouble(height.getText().toString());
                chiso = Math.round((canNang/Math.pow(chieuCao,2))*10.0)/10.0;
                if (rb_Famale.isChecked()){
                    if (chiso<18.5){
                        chisobmi.setText(String.valueOf(chiso));
                        nhanxet.setText("You need to provide protein!!!");
                    }
                    else if  (chiso>=18.5 && chiso <= 24.9){
                        chisobmi.setText(String.valueOf(chiso));
                        nhanxet.setText("Nomal");}
                    else if (chiso==25){
                        chisobmi.setText(String.valueOf(chiso));
                        nhanxet.setText("Pig");
                    }
                    else if  (chiso>25 && chiso<=29.9){
                        chisobmi.setText(String.valueOf(chiso));
                        nhanxet.setText("SuperPig 1");
                    }
                    else    if (chiso>=30 && chiso<=39.9){
                        chisobmi.setText(String.valueOf(chiso));
                        nhanxet.setText("SuperPig 2");
                    }
                }
               else if (rb_MALE.isChecked()){
                    if (chiso<18.5){
                        chisobmi.setText(String.valueOf(chiso));
                        nhanxet.setText("You need to provide protein!!!");
                    }
                    else if  (chiso>=18.5 && chiso <= 24.9){
                        chisobmi.setText(String.valueOf(chiso));
                        nhanxet.setText("Nomal");}
                    else if (chiso==25){
                        chisobmi.setText(String.valueOf(chiso));
                        nhanxet.setText("Pig");
                    }
                    else if  (chiso>25 && chiso<=29.9){
                        chisobmi.setText(String.valueOf(chiso));
                        nhanxet.setText("SuperPig 1");
                    }
                    else    if (chiso>=30 && chiso<=39.9){
                        chisobmi.setText(String.valueOf(chiso));
                        nhanxet.setText("SuperPig 2");
                    }
                }
               else {
                    Toast.makeText(getApplicationContext(),"Choose your Sex",
                    Toast.LENGTH_LONG).show();
                }
            }
        });

        }


}
