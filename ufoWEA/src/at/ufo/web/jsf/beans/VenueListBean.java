package at.ufo.web.jsf.beans;

import at.ufo.web.generated.Artist;
import at.ufo.web.generated.Venue;
import at.ufo.web.utils.Session;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;
import java.util.List;

/**
 * Created by Flow on 22.01.2016.
 */

@ManagedBean
@ViewScoped
public class VenueListBean implements Serializable {

    private List<Venue> venues;

    @PostConstruct
    public void init(){
        venues = Session.GetSoap().getNextVenuesPage().getVenue();
    }

    public List<Venue> getVenues() {
        return venues;
    }



}
