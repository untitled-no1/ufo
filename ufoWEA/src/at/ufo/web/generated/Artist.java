
package at.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java-Klasse für Artist complex type.
 * 
 * <p>Das folgende Schemafragment gibt den erwarteten Content an, der in dieser Klasse enthalten ist.
 * 
 * <pre>
 * &lt;complexType name="Artist">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="ArtistId" type="{http://www.w3.org/2001/XMLSchema}int"/>
 *         &lt;element name="Name" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="EMail" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="Category" type="{http://ufo.untitled-no1.at/webservice/}Category" minOccurs="0"/>
 *         &lt;element name="Country" type="{http://ufo.untitled-no1.at/webservice/}Country" minOccurs="0"/>
 *         &lt;element name="Picture" type="{http://ufo.untitled-no1.at/webservice/}BlobData" minOccurs="0"/>
 *         &lt;element name="PromoVideo" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Artist", propOrder = {
    "artistId",
    "name",
    "eMail",
    "category",
    "country",
    "picture",
    "promoVideo"
})
public class Artist {

    @XmlElement(name = "ArtistId")
    protected int artistId;
    @XmlElement(name = "Name")
    protected String name;
    @XmlElement(name = "EMail")
    protected String eMail;
    @XmlElement(name = "Category")
    protected Category category;
    @XmlElement(name = "Country")
    protected Country country;
    @XmlElement(name = "Picture")
    protected BlobData picture;
    @XmlElement(name = "PromoVideo")
    protected String promoVideo;

    /**
     * Ruft den Wert der artistId-Eigenschaft ab.
     * 
     */
    public int getArtistId() {
        return artistId;
    }

    /**
     * Legt den Wert der artistId-Eigenschaft fest.
     * 
     */
    public void setArtistId(int value) {
        this.artistId = value;
    }

    /**
     * Ruft den Wert der name-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getName() {
        return name;
    }

    /**
     * Legt den Wert der name-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setName(String value) {
        this.name = value;
    }

    /**
     * Ruft den Wert der eMail-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getEMail() {
        return eMail;
    }

    /**
     * Legt den Wert der eMail-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setEMail(String value) {
        this.eMail = value;
    }

    /**
     * Ruft den Wert der category-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Category }
     *     
     */
    public Category getCategory() {
        return category;
    }

    /**
     * Legt den Wert der category-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Category }
     *     
     */
    public void setCategory(Category value) {
        this.category = value;
    }

    /**
     * Ruft den Wert der country-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Country }
     *     
     */
    public Country getCountry() {
        return country;
    }

    /**
     * Legt den Wert der country-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Country }
     *     
     */
    public void setCountry(Country value) {
        this.country = value;
    }

    /**
     * Ruft den Wert der picture-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link BlobData }
     *     
     */
    public BlobData getPicture() {
        return picture;
    }

    /**
     * Legt den Wert der picture-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link BlobData }
     *     
     */
    public void setPicture(BlobData value) {
        this.picture = value;
    }

    /**
     * Ruft den Wert der promoVideo-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getPromoVideo() {
        return promoVideo;
    }

    /**
     * Legt den Wert der promoVideo-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPromoVideo(String value) {
        this.promoVideo = value;
    }

}
