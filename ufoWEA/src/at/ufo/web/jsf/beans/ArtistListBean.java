package at.ufo.web.jsf.beans;

import at.ufo.web.generated.Artist;
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
public class ArtistListBean implements Serializable {

    private List<Artist> artists;

    @PostConstruct
    public void init(){
        artists = Session.GetSoap().getNextArtistsPage().getArtist();
    }

    public List<Artist> getArtists() {
        return artists;
    }



}
