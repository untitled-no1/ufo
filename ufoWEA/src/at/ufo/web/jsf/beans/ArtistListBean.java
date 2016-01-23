package at.ufo.web.jsf.beans;

import at.ufo.web.generated.ArrayOfArtist;
import at.ufo.web.generated.Artist;
import at.ufo.web.generated.Page;
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
public class ArtistListBean implements Serializable {

    private List<Artist> artists;
    private Page artistPage;

    @PostConstruct
    public void init(){
        artistPage = Helper.CreateNewPage();
        artists = new ArrayList<>();
        ArrayOfArtist tmp = Session.GetSoap().getArtistsPage(artistPage);
        while(tmp != null && tmp.getArtist().size() > 0) {
            artists.addAll(tmp.getArtist());
            artistPage = Helper.CalcNextPage(artistPage);
            tmp = Session.GetSoap().getArtistsPage(artistPage);
        }
    }

    public List<Artist> getArtists() {
        return artists;
    }








}
