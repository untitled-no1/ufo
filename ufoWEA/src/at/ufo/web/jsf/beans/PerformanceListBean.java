package at.ufo.web.jsf.beans;

import at.ufo.web.generated.*;
import at.ufo.web.utils.Helper;
import at.ufo.web.utils.Session;
import com.sun.org.apache.xerces.internal.jaxp.datatype.XMLGregorianCalendarImpl;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

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

    private List<String> hours = new ArrayList<>();

    public PerformanceListBean() {
        for (int i = 14; i < 24; i++) {
            hours.add(i + ":00");
        }
        hours.add("00:00");
    }

    public void initPerformancesPerArtist() {
        artist = Session.GetSoap().getArtistById(artistId);
        // TODO performancesPerArtist = Session.GetSoap().getPerformancesPerArtist(artist);
    }

    public void initPerformancesPerVenue() {
        venue = Session.GetSoap().getVenueById(venueId);
        // TODO performancesPerVenue = Session.GetSoap().getPerformancesPerVenue(venue);
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





}
