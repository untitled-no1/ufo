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
    private int id;

    public void init() {
        artist = Session.GetSoap().getArtistById(id);
    }

    public Artist getArtist() {
        return artist;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getId() {
        return id;
    }

}
