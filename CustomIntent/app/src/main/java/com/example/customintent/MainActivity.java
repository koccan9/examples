package com.example.customintent;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;



public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        registerReceiver(new Receiver(),new IntentFilter("com.foo.bar"));
        sendBroadcast(new Intent("com.foo.bar"));//custom intent
    }
}