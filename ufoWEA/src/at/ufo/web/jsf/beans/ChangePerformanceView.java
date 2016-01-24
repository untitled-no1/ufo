package at.ufo.web.jsf.beans;

import at.ufo.web.generated.*;
import at.ufo.web.utils.Helper;
import at.ufo.web.utils.Session;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ManagedProperty;
import javax.faces.bean.ViewScoped;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import java.io.Serializable;
import java.util.*;

/**
 * Created by Flow on 24.01.2016.
 */
@ManagedBean
@ViewScoped
public class ChangePerformanceView implements Serializable {

    @ManagedProperty(value = "#{sessionBean}")
    private SessionBean sessionBean;
    public void setSessionBean(SessionBean sessionBean) { this.sessionBean = sessionBean; }

    private List<String> venues;
    private String pickedVenue;
    private Performance performance;
    private int day;
    private int month;
    private int year;
    private int hour;
    private boolean isActive = false;


    @ManagedProperty(value = "#{venueListBean}")
    private VenueListBean venueListBean;
    public void setVenueListBean(VenueListBean venueListBean) { this.venueListBean = venueListBean; }




    @PostConstruct
    public void init() {
        venues = new ArrayList<>();
        for (Venue v : venueListBean.getVenues()){
            venues.add(v.getName());
        }
    }

    public void InvokePerformance(Performance p) {
        this.performance = p;
        pickedVenue = p.getVenue().getName();

        day = p.getDateTime().getDay();
        month = p.getDateTime().getMonth();
        year = p.getDateTime().getYear();
        hour = p.getDateTime().getHour();
        isActive = true;
    }

    public void saveChanges(){
        Performance p = new Performance();
        p.setArtist(performance.getArtist());
        for(Venue v : venueListBean.getVenues()) {
            if(v.getName().equals(pickedVenue)) {
                p.setVenue(v);
                break;
            }
        }

        GregorianCalendar gcal = new GregorianCalendar();
        gcal.set(year, month-1, day, hour, 0, 0);
        XMLGregorianCalendar xgcal;
        try {
            xgcal = DatatypeFactory.newInstance().newXMLGregorianCalendar(gcal);
            p.setDateTime(xgcal);
            boolean res = Session.GetSoap().updatePerformance(sessionBean.getLoggedUser(), performance, p);
            System.out.println("Performance changed: " + res);
        } catch(DatatypeConfigurationException e){
            System.out.println("Date not valid");
        }
        Helper.Reload();

    }


    public List<String> getVenues() {
        return venues;
    }

    public void setVenues(List<String> venues) {
        this.venues = venues;
    }

    public String getPickedVenue() {
        return pickedVenue;
    }

    public void setPickedVenue(String pickedVenue) {
        this.pickedVenue = pickedVenue;
    }

    public Performance getPerformance() {
        return performance;
    }

    public void setPerformance(Performance performance) {
        this.performance = performance;
    }

    public int getDay() {
        return day;
    }

    public void setDay(int day) {
        this.day = day;
    }

    public int getMonth() {
        return month;
    }

    public void setMonth(int month) {
        this.month = month;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public int getHour() {
        return hour;
    }

    public void setHour(int hour) {
        this.hour = hour;
    }

    public boolean isActive() {
        return isActive;
    }

    public void setActive(boolean active) {
        isActive = active;
    }
}
