
package at.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
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
 *         &lt;element name="getPerformancesPerArtistResult" type="{http://ufo.untitled-no1.at/webservice/}ArrayOfPerformance" minOccurs="0"/>
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
    "getPerformancesPerArtistResult"
})
@XmlRootElement(name = "getPerformancesPerArtistResponse")
public class GetPerformancesPerArtistResponse {

    protected ArrayOfPerformance getPerformancesPerArtistResult;

    /**
     * Ruft den Wert der getPerformancesPerArtistResult-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfPerformance }
     *     
     */
    public ArrayOfPerformance getGetPerformancesPerArtistResult() {
        return getPerformancesPerArtistResult;
    }

    /**
     * Legt den Wert der getPerformancesPerArtistResult-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfPerformance }
     *     
     */
    public void setGetPerformancesPerArtistResult(ArrayOfPerformance value) {
        this.getPerformancesPerArtistResult = value;
    }

}
