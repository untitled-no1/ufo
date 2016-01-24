package at.ufo.web.jsf.beans;

import at.ufo.web.generated.User;
import at.ufo.web.utils.Helper;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
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
        Helper.Reload();
    }

    public void logout() {
        loggedUser = null;
        loggedIn = false;
        Helper.Reload();
    }

    public User getLoggedUser() {
        return loggedUser;
    }

    public boolean isLoggedIn(){
        return loggedIn;
    }
}
