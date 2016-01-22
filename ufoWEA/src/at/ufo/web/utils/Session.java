package at.ufo.web.utils;

import at.ufo.web.generated.DataWebService;
import at.ufo.web.generated.DataWebServiceSoap;

/**
 * Created by Flow on 22.01.2016.
 */
public class Session {
    private static DataWebServiceSoap soap;

    public static DataWebServiceSoap GetSoap() {

        if(soap == null) {
            DataWebService ws = new DataWebService();
            soap = ws.getDataWebServiceSoap();
        }
        return soap;
    }
}
