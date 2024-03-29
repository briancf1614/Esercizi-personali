package com.xpgsolutions.testtabletlayout;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private Button b1,b2,b3,b4,b5,b6,b7,b8,b9;
    private String jugador = "X";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        b1 = findViewById(R.id.b1);
        b2 = findViewById(R.id.b2);
        b3 = findViewById(R.id.b3);
        b4 = findViewById(R.id.b4);
        b5 = findViewById(R.id.b5);
        b6 = findViewById(R.id.b6);
        b7 = findViewById(R.id.b7);
        b8 = findViewById(R.id.b8);
        b9 = findViewById(R.id.b9);
    }
    public void jugar(View view){
        Button b = (Button)view;
        if(b.getText().toString().equals("")) {
            b.setText(jugador);
            checkVicita(jugador);
            cambioJugador();
            //b.setEnabled(false);

        }
    }

    public void cambioJugador(){
        if(this.jugador.equals("X"))
            this.jugador="O";
        else
            this.jugador="X";
    }

    public void checkVicita(String turno){
        String valor1 = b1.getText().toString();
        String valor2 = b2.getText().toString();
        String valor3 = b3.getText().toString();
        String valor4 = b4.getText().toString();
        String valor5 = b5.getText().toString();
        String valor6 = b6.getText().toString();
        String valor7 = b7.getText().toString();
        String valor8 = b8.getText().toString();
        String valor9 = b9.getText().toString();

        if(valor1.equals(turno) && valor2.equals(turno) && valor3.equals(turno))
            ganastes(turno);
        if(valor4.equals(turno) && valor5.equals(turno) && valor6.equals(turno))
            ganastes(turno);
        if(valor7.equals(turno) && valor8.equals(turno) && valor9.equals(turno))
            ganastes(turno);

        if(valor1.equals(turno) && valor4.equals(turno) && valor7.equals(turno))
            ganastes(turno);
        if(valor2.equals(turno) && valor5.equals(turno) && valor8.equals(turno))
            ganastes(turno);
        if(valor3.equals(turno) && valor6.equals(turno) && valor9.equals(turno))
            ganastes(turno);

        if(valor1.equals(turno) && valor5.equals(turno) && valor9.equals(turno))
            ganastes(turno);
        if(valor3.equals(turno) && valor5.equals(turno) && valor7.equals(turno))
            ganastes(turno);
    }

    public void ganastes(String turno){
        Toast.makeText(this, "Felicidades " + turno + " has ganado", Toast.LENGTH_SHORT).show();
        b1.setEnabled(false);
        b2.setEnabled(false);
        b3.setEnabled(false);
        b4.setEnabled(false);
        b5.setEnabled(false);
        b6.setEnabled(false);
        b7.setEnabled(false);
        b8.setEnabled(false);
        b9.setEnabled(false);
    }
    public void uscire(View view){
        recreate();
    }

}