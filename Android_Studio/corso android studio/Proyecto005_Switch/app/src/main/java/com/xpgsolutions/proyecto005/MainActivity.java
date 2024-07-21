package com.xpgsolutions.proyecto005;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Switch;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private Switch switch1, switch2;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        switch1 = findViewById(R.id.switch1);
        switch2 = findViewById(R.id.switch2);
    }
    public void verificar(View view){
        if(switch1.isChecked())
            Toast.makeText(this, "Los datos moviles estan activados papu :v", Toast.LENGTH_SHORT).show();
        else
            Toast.makeText(this, "Los datos moviles estan desactivados Papu :_(", Toast.LENGTH_SHORT).show();
        if(switch2.isChecked())
            Toast.makeText(this, "El wifi esta activado papu :v", Toast.LENGTH_SHORT).show();
        else
            Toast.makeText(this, "El wifi esta desactivado Papu :_(", Toast.LENGTH_SHORT).show();
    }
    public void verificarDatosMobiles(View view){
        if(switch1.isChecked())
            Toast.makeText(this, "Se acaba de activar datos mobiles", Toast.LENGTH_SHORT).show();
        else
            Toast.makeText(this, "Se acaba de desativar los datos mobilies", Toast.LENGTH_SHORT).show();
    }
    public void verificarWifi(View view){
        if(switch2.isChecked())
            Toast.makeText(this, "Se acaba de activar el wifi", Toast.LENGTH_SHORT).show();
        else
            Toast.makeText(this, "Se acaba de desativar el wifi", Toast.LENGTH_SHORT).show();
    }
}