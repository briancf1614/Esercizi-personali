package com.xpgsolutions.recyclerviewexample.adapter;

import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.xpgsolutions.recyclerviewexample.R;
import com.xpgsolutions.recyclerviewexample.Superhero;

//questo RecyclerView ha un condtructor che richiede un View, per quello usiamo il super, simile al base di c#
public class SuperHeroViewHolder extends RecyclerView.ViewHolder {
    private TextView publisher;
    private ImageView photo;
    private TextView superHero;
    private TextView realName;
    private View view;


    public SuperHeroViewHolder(View view) {
        super(view);
        this.view = view;

        superHero = view.findViewById(R.id.tvSuperHeroName);
        realName = view.findViewById(R.id.tvRealName);
        publisher = view.findViewById(R.id.tvPublisher);
        photo = view.findViewById(R.id.ivSuperHero);
    }




    public void render(Superhero superHeroModel){
        superHero.setText(superHeroModel.getSuperhero());
        realName.setText(superHeroModel.getRealName());
        publisher.setText(superHeroModel.getPublisher());
        Glide.with(photo.getContext()).load(superHeroModel.getPhoto()).into(photo);

    }
}
