
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
 *         &lt;element name="GetArtistByNameResult" type="{http://ufo.untitled-no1.at/webservice/}Artist" minOccurs="0"/>
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
    "getArtistByNameResult"
})
@XmlRootElement(name = "GetArtistByNameResponse")
public class GetArtistByNameResponse {

    @XmlElement(name = "GetArtistByNameResult")
    protected Artist getArtistByNameResult;

    /**
     * Ruft den Wert der getArtistByNameResult-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Artist }
     *     
     */
    public Artist getGetArtistByNameResult() {
        return getArtistByNameResult;
    }

    /**
     * Legt den Wert der getArtistByNameResult-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Artist }
     *     
     */
    public void setGetArtistByNameResult(Artist value) {
        this.getArtistByNameResult = value;
    }

}
