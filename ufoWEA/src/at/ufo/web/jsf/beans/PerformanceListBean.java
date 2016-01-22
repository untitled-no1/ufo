package at.ufo.web.jsf.beans;

import at.ufo.web.generated.Performance;
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
public class PerformanceListBean implements Serializable {

    private List<Performance> performances;

    @PostConstruct
    public void init(){
        performances = Session.GetSoap().getNextPerformancesPage().getPerformance();
    }

    public List<Performance> getPerformances() {
        return performances;
    }



}
