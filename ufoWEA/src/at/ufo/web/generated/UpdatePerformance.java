
package at.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
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
 *         &lt;element name="u" type="{http://ufo.untitled-no1.at/webservice/}User" minOccurs="0"/>
 *         &lt;element name="oldPerformance" type="{http://ufo.untitled-no1.at/webservice/}Performance" minOccurs="0"/>
 *         &lt;element name="newPerformance" type="{http://ufo.untitled-no1.at/webservice/}Performance" minOccurs="0"/>
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
    "u",
    "oldPerformance",
    "newPerformance"
})
@XmlRootElement(name = "UpdatePerformance")
public class UpdatePerformance {

    protected User u;
    protected Performance oldPerformance;
    protected Performance newPerformance;

    /**
     * Ruft den Wert der u-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link User }
     *     
     */
    public User getU() {
        return u;
    }

    /**
     * Legt den Wert der u-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link User }
     *     
     */
    public void setU(User value) {
        this.u = value;
    }

    /**
     * Ruft den Wert der oldPerformance-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Performance }
     *     
     */
    public Performance getOldPerformance() {
        return oldPerformance;
    }

    /**
     * Legt den Wert der oldPerformance-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Performance }
     *     
     */
    public void setOldPerformance(Performance value) {
        this.oldPerformance = value;
    }

    /**
     * Ruft den Wert der newPerformance-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Performance }
     *     
     */
    public Performance getNewPerformance() {
        return newPerformance;
    }

    /**
     * Legt den Wert der newPerformance-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Performance }
     *     
     */
    public void setNewPerformance(Performance value) {
        this.newPerformance = value;
    }

}
