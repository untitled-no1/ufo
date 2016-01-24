package at.ufo.web.utils;

import at.ufo.web.generated.Page;

import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;

/**
 * Created by Flow on 22.01.2016.
 */
public class Helper {

    public static Page CalcNextPage(Page p) {
        int offset = p.getOffset();
        int size = p.getSize();
        offset += size;
        p.setOffset(offset);
        return p;
    }

    public static Page CreateNewPage() {
        Page p = new Page();
        p.setOffset(0);
        p.setSize(50);
        return p;
    }

    public static void Reload() {
        ExternalContext ec = FacesContext.getCurrentInstance().getExternalContext();
        try {
            ec.redirect(((HttpServletRequest) ec.getRequest()).getRequestURI());
        } catch (IOException e) {
            System.err.println("RELOAD NOT POSSIBLE");
        }
    }
}
