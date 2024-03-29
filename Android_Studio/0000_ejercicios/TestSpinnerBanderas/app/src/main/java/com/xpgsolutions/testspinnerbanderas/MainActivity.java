package com.xpgsolutions.testspinnerbanderas;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private Spinner spinner;
    private ImageView iv1;
    private TextView tv1;
    private String[] paises = {"Argentina","Bolivia","Brasil"};
    private int[] referBanderas = {R.drawable.argentina,R.drawable.bolivia,R.drawable.brasil};
    @Override
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        spinner = findViewById(R.id.spinner);
        PaisesAdapter adaptador = new PaisesAdapter();
        spinner.setAdapter(adaptador);
    }

    class PaisesAdapter extends BaseAdapter{
        @Override
        public int getCount() {
            return paises.length;
        }

        @Override
        public Object getItem(int position) {
            return paises[position];
        }

        @Override
        public long getItemId(int position) {
            return 0;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent){
            LayoutInflater inflater = LayoutInflater.from(MainActivity.this);
            convertView = inflater.inflate(R.layout.itemspinner,null);
            ImageView iv1 = convertView.findViewById(R.id.imageView);
            TextView tv1 = convertView.findViewById(R.id.tvpais);
            iv1.setImageResource(referBanderas[position]);
            tv1.setText(paises[position]);
            return convertView;
        }
    }
}