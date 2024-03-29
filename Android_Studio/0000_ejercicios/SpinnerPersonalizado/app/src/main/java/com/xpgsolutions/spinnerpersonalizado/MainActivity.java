package com.xpgsolutions.spinnerpersonalizado;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private Spinner spinner;
    private String[] Paises = {"Argentina","Bolivia","Brasil"};
    private int[] banderas = {R.drawable.argentina,R.drawable.bolivia,R.drawable.brasil};
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        spinner = findViewById(R.id.spinner);
        PaisesAdapter adapter = new PaisesAdapter();
        spinner.setAdapter(adapter);
    }

    private class PaisesAdapter extends BaseAdapter {
        @Override
        public int getCount() {
            return Paises.length;
        }

        @Override
        public Object getItem(int position) {
            return Paises[position];
        }

        @Override
        public long getItemId(int position) {
            return 0;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            LayoutInflater inflater = LayoutInflater.from(MainActivity.this);
            convertView = inflater.inflate(R.layout.spinnerlayout,null);
            TextView tv1 = convertView.findViewById(R.id.tvpais);
            ImageView iv1 = convertView.findViewById(R.id.ivpais);
            tv1.setText(Paises[position]);
            iv1.setImageResource(banderas[position]);
            return convertView;
        }
    }
}