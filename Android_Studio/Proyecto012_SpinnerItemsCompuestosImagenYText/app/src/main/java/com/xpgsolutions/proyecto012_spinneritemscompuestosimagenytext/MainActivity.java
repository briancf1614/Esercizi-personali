package com.xpgsolutions.proyecto012_spinneritemscompuestosimagenytext;

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

    String[] paises = {"Argentina", "Bolivia", "Brasil"};
    int[] banderas = {R.drawable.argentina, R.drawable.bolivia, R.drawable.brasil};
    private Spinner spinner;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        spinner = findViewById(R.id.spinner);

        PaisesAdapter adaptador1 = new PaisesAdapter();
        spinner.setAdapter(adaptador1);
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
        public View getView(int position, View convertView, ViewGroup parent) {
            LayoutInflater inflater = LayoutInflater.from(MainActivity.this);
            convertView = inflater.inflate(R.layout.itemspinner,null);
            ImageView iv1 = convertView.findViewById(R.id.imageView);
            TextView tv1 = convertView.findViewById(R.id.tvpais);
            iv1.setImageResource(banderas[position]);
            tv1.setText(paises[position]);
            return convertView;
        }
    }
}