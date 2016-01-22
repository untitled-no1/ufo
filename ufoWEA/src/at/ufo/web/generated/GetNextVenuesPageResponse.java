
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
 *         &lt;element name="GetNextVenuesPageResult" type="{http://ufo.untitled-no1.at/webservice/}ArrayOfVenue" minOccurs="0"/>
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
    "getNextVenuesPageResult"
})
@XmlRootElement(name = "GetNextVenuesPageResponse")
public class GetNextVenuesPageResponse {

    @XmlElement(name = "GetNextVenuesPageResult")
    protected ArrayOfVenue getNextVenuesPageResult;

    /**
     * Ruft den Wert der getNextVenuesPageResult-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfVenue }
     *     
     */
    public ArrayOfVenue getGetNextVenuesPageResult() {
        return getNextVenuesPageResult;
    }

    /**
     * Legt den Wert der getNextVenuesPageResult-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfVenue }
     *     
     */
    public void setGetNextVenuesPageResult(ArrayOfVenue value) {
        this.getNextVenuesPageResult = value;
    }

}
