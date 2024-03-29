package com.example.eliminar.ChecklistJsonClass;

import java.util.List;

public class Passo {
    private String id;
    private String matricola_oper;
    private String operatore;
    private List<Campi> campi;
    private List<Transizioni> transizioni;




    //    Getters and Setters
    public String getId() {
        return id;
    }
    public void setId(String id) {
        this.id = id;
    }
    public String getMatricola_oper() {
        return matricola_oper;
    }
    public void setMatricola_oper(String matricola_oper) {
        this.matricola_oper = matricola_oper;
    }
    public String getOperatore() {
        return operatore;
    }
    public void setOperatore(String operatore) {
        this.operatore = operatore;
    }
    public List<Campi> getCampi() {
        return campi;
    }
    public void setCampi(List<Campi> campi) {
        this.campi = campi;
    }
    public List<Transizioni> getTransizioni() {
        return transizioni;
    }
    public void setTransizioni(List<Transizioni> transizioni) {
        this.transizioni = transizioni;
    }

}
