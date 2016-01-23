package at.ufo.web.jsf.beans;

import at.ufo.web.generated.ArrayOfVenue;
import at.ufo.web.generated.Artist;
import at.ufo.web.generated.Page;
import at.ufo.web.generated.Venue;
import at.ufo.web.utils.Helper;
import at.ufo.web.utils.Session;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Flow on 22.01.2016.
 */

@ManagedBean
@ViewScoped
public class VenueListBean implements Serializable {

    private List<Venue> venues;
    private Page venuePage;

    @PostConstruct
    public void init(){
        venuePage = Helper.CreateNewPage();
        venues = new ArrayList<>();
        ArrayOfVenue tmp = Session.GetSoap().getVenuesPage(venuePage);
        while(tmp != null && tmp.getVenue().size() > 0) {
            venues.addAll(tmp.getVenue());
            venuePage = Helper.CalcNextPage(venuePage);
            tmp = Session.GetSoap().getVenuesPage(venuePage);
        }
    }

    public List<Venue> getVenues() {
        return venues;
    }



}
