
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
 *         &lt;element name="GetArtistByIdResult" type="{http://ufo.untitled-no1.at/webservice/}Artist" minOccurs="0"/>
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
    "getArtistByIdResult"
})
@XmlRootElement(name = "GetArtistByIdResponse")
public class GetArtistByIdResponse {

    @XmlElement(name = "GetArtistByIdResult")
    protected Artist getArtistByIdResult;

    /**
     * Ruft den Wert der getArtistByIdResult-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Artist }
     *     
     */
    public Artist getGetArtistByIdResult() {
        return getArtistByIdResult;
    }

    /**
     * Legt den Wert der getArtistByIdResult-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Artist }
     *     
     */
    public void setGetArtistByIdResult(Artist value) {
        this.getArtistByIdResult = value;
    }

}
