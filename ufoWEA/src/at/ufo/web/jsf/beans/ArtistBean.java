package at.ufo.web.jsf.beans;

import at.ufo.web.generated.Artist;
import at.ufo.web.generated.DataWebService;
import at.ufo.web.generated.DataWebServiceSoap;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;

/**
 * Created by Flow on 19.01.2016.
 */
@ManagedBean
@ViewScoped
public class ArtistBean {

    private Artist artist;

    @PostConstruct
    public void init() {
        DataWebService ws = new DataWebService();
        DataWebServiceSoap soap = ws.getDataWebServiceSoap();
        artist = soap.getArtistByName("dd");
    }

    public Artist getArtist() {
        return artist;
    }

}
