
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
 *         &lt;element name="p" type="{http://ufo.untitled-no1.at/webservice/}Performance" minOccurs="0"/>
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
    "p"
})
@XmlRootElement(name = "deletePerformance")
public class DeletePerformance {

    protected User u;
    protected Performance p;

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
     * Ruft den Wert der p-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Performance }
     *     
     */
    public Performance getP() {
        return p;
    }

    /**
     * Legt den Wert der p-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Performance }
     *     
     */
    public void setP(Performance value) {
        this.p = value;
    }

}
