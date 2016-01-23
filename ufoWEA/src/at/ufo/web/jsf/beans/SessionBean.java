package at.ufo.web.jsf.beans;

import at.ufo.web.generated.User;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import java.io.Serializable;

/**
 * Created by Flow on 23.01.2016.
 */

@ManagedBean(name = "sessionBean")
@SessionScoped
public class SessionBean implements Serializable {

    private User loggedUser;
    private boolean loggedIn;

    public void setLoggedUser(User u) {
        loggedUser = u;
        loggedIn = true;
    }

    public void logout() {
        loggedUser = null;
        loggedIn = false;
    }

    public User getLoggedUser() {
        return loggedUser;
    }

    public boolean isLoggedIn(){
        return loggedIn;
    }
}
