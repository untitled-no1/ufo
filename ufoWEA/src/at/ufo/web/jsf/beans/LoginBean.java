package at.ufo.web.jsf.beans;

import at.ufo.web.generated.User;
import at.ufo.web.utils.Hash;
import at.ufo.web.utils.Session;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ManagedProperty;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;

/**
 * Created by Flow on 23.01.2016.
 */
@ManagedBean
@ViewScoped
public class LoginBean implements Serializable{

    private String username;
    private String passwordHash;
    private String hashed;

    @ManagedProperty(value = "#{sessionBean}")
    private SessionBean sessionBean;
    public void setSessionBean(SessionBean sessionBean) { this.sessionBean = sessionBean; }

    @PostConstruct
    public void init() {
        username = "";
        passwordHash = "";
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPasswordHash() {
        return passwordHash;
    }

    public void setPasswordHash(String passwordHash) {
        hashed = Hash.getMD5(passwordHash);
        this.passwordHash = passwordHash;
    }

    public boolean isLoggedIn(){
        return sessionBean.isLoggedIn();
    }

    public User getLoggedUser() {
        return sessionBean.getLoggedUser();
    }

    public void LoginClick() {
        User u = Session.GetSoap().logIn(username, hashed);
        if(u != null) {
            sessionBean.setLoggedUser(u);
            System.out.println(u.getEMail() + " is logged in");
        }
    }

    public void LogoutClick() {
        sessionBean.logout();
    }
}
