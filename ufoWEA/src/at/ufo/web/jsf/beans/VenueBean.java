package at.ufo.web.jsf.beans;



import at.ufo.web.generated.Venue;
import at.ufo.web.utils.Session;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;


@ManagedBean
@ViewScoped
public class VenueBean implements Serializable {

    private String venueId;
    private Venue venue;

    public void init() {
        venue = Session.GetSoap().getVenueById(venueId);
    }

    public String getVenueId() {
        return venueId;
    }

    public void setVenueId(String venueId) {
        this.venueId = venueId;
    }

    public Venue getVenue() {
        return venue;
    }

}