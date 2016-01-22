package at.ufo.web.jsf.beans;

import at.ufo.web.generated.Artist;
import at.ufo.web.utils.Session;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;

/**
 * Created by Flow on 19.01.2016.
 */
@ManagedBean
@ViewScoped
public class ArtistBean implements Serializable{

    private Artist artist;

    @PostConstruct
    public void init() {

        artist = Session.GetSoap().getArtistByName("Ace");
    }

    public Artist getArtist() {
        return artist;
    }

}
