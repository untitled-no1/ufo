
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
 *         &lt;element name="GetNextArtistsPageResult" type="{http://ufo.untitled-no1.at/webservice/}ArrayOfArtist" minOccurs="0"/>
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
    "getNextArtistsPageResult"
})
@XmlRootElement(name = "GetNextArtistsPageResponse")
public class GetNextArtistsPageResponse {

    @XmlElement(name = "GetNextArtistsPageResult")
    protected ArrayOfArtist getNextArtistsPageResult;

    /**
     * Ruft den Wert der getNextArtistsPageResult-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfArtist }
     *     
     */
    public ArrayOfArtist getGetNextArtistsPageResult() {
        return getNextArtistsPageResult;
    }

    /**
     * Legt den Wert der getNextArtistsPageResult-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfArtist }
     *     
     */
    public void setGetNextArtistsPageResult(ArrayOfArtist value) {
        this.getNextArtistsPageResult = value;
    }

}
