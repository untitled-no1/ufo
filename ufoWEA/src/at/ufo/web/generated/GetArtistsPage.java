
package at.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java-Klasse f�r anonymous complex type.
 * 
 * <p>Das folgende Schemafragment gibt den erwarteten Content an, der in dieser Klasse enthalten ist.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="ArtistPage" type="{http://ufo.untitled-no1.at/webservice/}Page" minOccurs="0"/>
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
    "artistPage"
})
@XmlRootElement(name = "GetArtistsPage")
public class GetArtistsPage {

    @XmlElement(name = "ArtistPage")
    protected Page artistPage;

    /**
     * Ruft den Wert der artistPage-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Page }
     *     
     */
    public Page getArtistPage() {
        return artistPage;
    }

    /**
     * Legt den Wert der artistPage-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Page }
     *     
     */
    public void setArtistPage(Page value) {
        this.artistPage = value;
    }

}
