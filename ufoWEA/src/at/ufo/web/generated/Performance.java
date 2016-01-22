
package at.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;


/**
 * <p>Java-Klasse für Performance complex type.
 * 
 * <p>Das folgende Schemafragment gibt den erwarteten Content an, der in dieser Klasse enthalten ist.
 * 
 * <pre>
 * &lt;complexType name="Performance">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="DateTime" type="{http://www.w3.org/2001/XMLSchema}dateTime"/>
 *         &lt;element name="Artist" type="{http://ufo.untitled-no1.at/webservice/}Artist" minOccurs="0"/>
 *         &lt;element name="Venue" type="{http://ufo.untitled-no1.at/webservice/}Venue" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Performance", propOrder = {
    "dateTime",
    "artist",
    "venue"
})
public class Performance {

    @XmlElement(name = "DateTime", required = true)
    @XmlSchemaType(name = "dateTime")
    protected XMLGregorianCalendar dateTime;
    @XmlElement(name = "Artist")
    protected Artist artist;
    @XmlElement(name = "Venue")
    protected Venue venue;

    /**
     * Ruft den Wert der dateTime-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getDateTime() {
        return dateTime;
    }

    /**
     * Legt den Wert der dateTime-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setDateTime(XMLGregorianCalendar value) {
        this.dateTime = value;
    }

    /**
     * Ruft den Wert der artist-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Artist }
     *     
     */
    public Artist getArtist() {
        return artist;
    }

    /**
     * Legt den Wert der artist-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Artist }
     *     
     */
    public void setArtist(Artist value) {
        this.artist = value;
    }

    /**
     * Ruft den Wert der venue-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Venue }
     *     
     */
    public Venue getVenue() {
        return venue;
    }

    /**
     * Legt den Wert der venue-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Venue }
     *     
     */
    public void setVenue(Venue value) {
        this.venue = value;
    }

}
