package com.example.eliminar.ChecklistJsonClass;

import java.util.List;

public class Campi {


    private String id;
    private String tipo;
    private String msg;
    private String valore;
    private String urlverifica;
    private List<Chiavi_valori> chiavi_valori;




//    Getters and Setters
    public String getId() {
        return id;
    }
    public void setId(String id) {
        this.id = id;
    }
    public String getTipo() {
        return tipo;
    }
    public void setTipo(String tipo) {
        this.tipo = tipo;
    }
    public String getMsg() {
        return msg;
    }
    public void setMsg(String msg) {
        this.msg = msg;
    }
    public String getValore() {
        return valore;
    }
    public void setValore(String valore) {
        this.valore = valore;
    }
    public String getUrlverifica() {
        return urlverifica;
    }
    public void setUrlverifica(String urlverifica) {
        this.urlverifica = urlverifica;
    }
    public List<Chiavi_valori> getChiavi_valori() {
        return chiavi_valori;
    }
    public void setChiavi_valori(List<Chiavi_valori> chiavi_valori) {
        this.chiavi_valori = chiavi_valori;
    }
}
