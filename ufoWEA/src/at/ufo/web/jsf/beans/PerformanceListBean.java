package at.ufo.web.jsf.beans;

import at.ufo.web.generated.*;
import at.ufo.web.utils.Helper;
import at.ufo.web.utils.Session;
import com.sun.org.apache.xerces.internal.jaxp.datatype.XMLGregorianCalendarImpl;
import org.primefaces.event.SelectEvent;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ManagedProperty;
import javax.faces.bean.ViewScoped;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.*;

/**
 * Created by Flow on 22.01.2016.
 */

@ManagedBean
@ViewScoped
public class PerformanceListBean implements Serializable {

    private List<Performance> performances;
    private List<Performance> performancesPerVenue;
    private List<Performance> performancesPerArtist;
    private Page performancePage;
    private int artistId;
    private Artist artist;
    private String venueId;
    private Venue venue = new Venue();
    private SimpleDateFormat timeFormatter = new SimpleDateFormat("HH:mm");
    private SimpleDateFormat dateFormatter = new SimpleDateFormat("dd.MM.yyyy");
    private SimpleDateFormat fullDateFormatter = new SimpleDateFormat("dd.MM.yyyy HH:mm");

    private List<String> hours = new ArrayList<>();
    private Date date = Calendar.getInstance().getTime();


    @ManagedProperty(value = "#{sessionBean}")
    private SessionBean sessionBean;
    public void setSessionBean(SessionBean sessionBean) { this.sessionBean = sessionBean; }



    public PerformanceListBean() {
        for (int i = 14; i < 24; i++) {
            hours.add(i + ":00");
        }
        hours.add("00:00");
    }

    public void initPerformancesPerArtist() {
        artist = Session.GetSoap().getArtistById(artistId);
        ArrayOfPerformance tmp = Session.GetSoap().getPerformancesPerArtist(artistId);
        if(tmp == null) {
            tmp = new ArrayOfPerformance();
        }
        performancesPerArtist = tmp.getPerformance();
    }

    public void initPerformancesPerVenue() {
        venue = Session.GetSoap().getVenueById(venueId);
        ArrayOfPerformance tmp = Session.GetSoap().getPerformancesPerVenue(venueId);
        if(tmp == null)
            tmp = new ArrayOfPerformance();
        performancesPerVenue = tmp.getPerformance();
    }

    @PostConstruct
    public void init(){
        performancePage = Helper.CreateNewPage();
        performances = new ArrayList<>();
        ArrayOfPerformance tmp = Session.GetSoap().getPerformancesPage(performancePage);
        while(tmp != null && tmp.getPerformance().size() > 0) {
            performances.addAll(tmp.getPerformance());
            performancePage = Helper.CalcNextPage(performancePage);
            tmp = Session.GetSoap().getPerformancesPage(performancePage);
        }
    }

    public List<Performance> getPerformances() {
        return performances;
    }

    public List<Performance> getPerformancesPerArtist() {
        return performancesPerArtist;
    }

    public int getArtistId() {
        return artistId;
    }

    public void setArtistId(int artistId) {
        this.artistId = artistId;
    }

    public List<Performance> getPerformancesPerVenue() {
        return performancesPerVenue;
    }

    public String getVenueId() {
        return venueId;
    }

    public void setVenueId(String venueId) {
        this.venueId = venueId;
    }

    public List<String> getHours() {
        return hours;
    }

    public String checkPerformanceAvailable(Performance p, String hour) {
        Calendar cal = p.getDateTime().toGregorianCalendar();
        String perfHour = timeFormatter.format(cal.getTime());
        return perfHour.equals(hour) ? p.getArtist().getName() : "";
    }

    public String toDateString(XMLGregorianCalendarImpl calendar) {
        return dateFormatter.format(calendar.toGregorianCalendar().getTime());
    }


    public void setDate(Date date) {
        this.date = date;
    }

    public Date getDate() {
        return date;
    }

    public void dateChange(SelectEvent event)  {
        this.date = (Date)event.getObject();
        GregorianCalendar gcal = new GregorianCalendar();
        gcal.setTime(date);
        XMLGregorianCalendar xgcal;
        try {
            xgcal = DatatypeFactory.newInstance().newXMLGregorianCalendar(gcal);
            ArrayOfPerformance tmp = Session.GetSoap().getPerformancesPerDate(xgcal);
            if(tmp != null)
                performances = tmp.getPerformance();
        } catch(DatatypeConfigurationException e){
            performances = null;
            System.out.println("Date not valid");
        }

    }

    public void delete(Performance p) {
        if (!sessionBean.isLoggedIn())
            return;
        performances.remove(p);
        Session.GetSoap().deletePerformance(sessionBean.getLoggedUser(), p);
    }


}
