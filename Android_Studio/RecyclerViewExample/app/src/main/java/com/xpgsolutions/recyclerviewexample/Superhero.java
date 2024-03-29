package com.xpgsolutions.recyclerviewexample;

public class Superhero {
    public Superhero(String superhero, String publisher, String realName, String photo) {
        this.superhero = superhero;
        this.publisher = publisher;
        this.realName = realName;
        this.photo = photo;
    }

    public String getSuperhero() {
        return superhero;
    }

    public String getPublisher() {
        return publisher;
    }

    public String getRealName() {
        return realName;
    }

    public String getPhoto() {
        return photo;
    }

    private String superhero, publisher, realName, photo;



}
