
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
 *         &lt;element name="GetVenuesPageResult" type="{http://ufo.untitled-no1.at/webservice/}ArrayOfVenue" minOccurs="0"/>
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
    "getVenuesPageResult"
})
@XmlRootElement(name = "GetVenuesPageResponse")
public class GetVenuesPageResponse {

    @XmlElement(name = "GetVenuesPageResult")
    protected ArrayOfVenue getVenuesPageResult;

    /**
     * Ruft den Wert der getVenuesPageResult-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfVenue }
     *     
     */
    public ArrayOfVenue getGetVenuesPageResult() {
        return getVenuesPageResult;
    }

    /**
     * Legt den Wert der getVenuesPageResult-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfVenue }
     *     
     */
    public void setGetVenuesPageResult(ArrayOfVenue value) {
        this.getVenuesPageResult = value;
    }

}
