package com.xpgsolutions.recyclerviewexample.adapter;

import android.view.LayoutInflater;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.xpgsolutions.recyclerviewexample.R;
import com.xpgsolutions.recyclerviewexample.Superhero;

import java.util.List;

//extendiamo da un RecycleView.Adapter di tipo che volgiamo avere
public class SuperHeroAdapter extends RecyclerView.Adapter<SuperHeroViewHolder> {

    private List<Superhero> superheroList;

    public SuperHeroAdapter(List<Superhero> superheroList) {
        this.superheroList = superheroList;
    }

    @NonNull
    @Override
    public SuperHeroViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
//        aunque no estemos dentro de un activity aun podemos obtener el contexto a traves de la vista Viewgroup parent del metodo y creamos un layoutinflater
        LayoutInflater layoutInflater = LayoutInflater.from(parent.getContext());
//        creera uno per ogni coso che abbiamo nel superheroList.size()
        return new SuperHeroViewHolder(layoutInflater.inflate(R.layout.item_superhero, parent, false));
    }

    @Override
    public void onBindViewHolder(@NonNull SuperHeroViewHolder holder, int position) {
        Superhero item = superheroList.get(position);
        holder.render(item);

    }

    @Override
    public int getItemCount() {
        return superheroList.size();
    }
}
