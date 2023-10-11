package com.example.autocompletetextview;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    AutoCompleteTextView autoQuocGia;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        findControll();
       ArrayList<String> dsQuocGia = new ArrayList<String>();
        dsQuocGia.add("VietNam");
        dsQuocGia.add("Japan");
        dsQuocGia.add("USA");
        dsQuocGia.add("CuBa");

        ArrayAdapter<String> adapterQG;
        adapterQG = new ArrayAdapter<String>(
                              this, androidx.appcompat.R.layout.support_simple_spinner_dropdown_item,
                                     dsQuocGia
        );
        autoQuocGia.setAdapter(adapterQG);
    }

    public void findControll(){
        autoQuocGia = findViewById(R.id.autoCompleteQuocGia);
    }
}