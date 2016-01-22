
package at.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java-Klasse für anonymous complex type.
 * 
 * <p>Das folgende Schemafragment gibt den erwarteten Content an, der in dieser Klasse enthalten ist.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="GetVenueByIdResult" type="{http://ufo.untitled-no1.at/webservice/}Venue" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "getVenueByIdResult"
})
@XmlRootElement(name = "GetVenueByIdResponse")
public class GetVenueByIdResponse {

    @XmlElement(name = "GetVenueByIdResult")
    protected Venue getVenueByIdResult;

    /**
     * Ruft den Wert der getVenueByIdResult-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Venue }
     *     
     */
    public Venue getGetVenueByIdResult() {
        return getVenueByIdResult;
    }

    /**
     * Legt den Wert der getVenueByIdResult-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Venue }
     *     
     */
    public void setGetVenueByIdResult(Venue value) {
        this.getVenueByIdResult = value;
    }

}
