package com.xpgsolutions.proyecto008_tablelayout;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
    private String jugador = "X";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        btn1 = findViewById(R.id.btn1);
        btn2 = findViewById(R.id.btn2);
        btn3 = findViewById(R.id.btn3);
        btn4 = findViewById(R.id.btn4);
        btn5 = findViewById(R.id.btn5);
        btn6 = findViewById(R.id.btn6);
        btn7 = findViewById(R.id.btn7);
        btn8 = findViewById(R.id.btn8);
        btn9 = findViewById(R.id.btn9);
    }

    public void presion(View view) {
        Button b = (Button) view;
        if (b.getText().toString().equals("")){
            b.setText(jugador);
            verificarGano(jugador);
            cambiarJugador();
        }
    }

    private void verificarGano(String turno) {
        String casilla1 = btn1.getText().toString();
        String casilla2 = btn2.getText().toString();
        String casilla3 = btn3.getText().toString();
        String casilla4 = btn4.getText().toString();
        String casilla5 = btn5.getText().toString();
        String casilla6 = btn6.getText().toString();
        String casilla7 = btn7.getText().toString();
        String casilla8 = btn8.getText().toString();
        String casilla9 = btn9.getText().toString();

        if(casilla1.equals(turno) && casilla2.equals(turno) && casilla3.equals(turno))
            ganador(turno);
        if(casilla4.equals(turno) && casilla5.equals(turno) && casilla6.equals(turno))
            ganador(turno);
        if(casilla7.equals(turno) && casilla8.equals(turno) && casilla9.equals(turno))
            ganador(turno);
        if(casilla1.equals(turno) && casilla4.equals(turno) && casilla7.equals(turno))
            ganador(turno);
        if(casilla2.equals(turno) && casilla5.equals(turno) && casilla8.equals(turno))
            ganador(turno);
        if(casilla3.equals(turno) && casilla6.equals(turno) && casilla9.equals(turno))
            ganador(turno);
        if(casilla1.equals(turno) && casilla5.equals(turno) && casilla9.equals(turno))
            ganador(turno);
        if(casilla3.equals(turno) && casilla5.equals(turno) && casilla7.equals(turno))
            ganador(turno);
    }
        public void ganador(String turno){
            Toast.makeText(this, "Felicidades Mister  " + turno + "  acabas de ganar", Toast.LENGTH_SHORT).show();
            btn1.setEnabled(false);
            btn2.setEnabled(false);
            btn3.setEnabled(false);
            btn4.setEnabled(false);
            btn5.setEnabled(false);
            btn6.setEnabled(false);
            btn7.setEnabled(false);
            btn8.setEnabled(false);
            btn9.setEnabled(false);
        }
    private void cambiarJugador() {
        if (jugador.equals("X"))
            jugador = "O";
        else
            jugador = "X";
    }
    public void salir(View view) {
        finish();
    }

    }
