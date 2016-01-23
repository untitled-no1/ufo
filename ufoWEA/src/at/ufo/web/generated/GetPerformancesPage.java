
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
 *         &lt;element name="PerformancePage" type="{http://ufo.untitled-no1.at/webservice/}Page" minOccurs="0"/>
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
    "performancePage"
})
@XmlRootElement(name = "GetPerformancesPage")
public class GetPerformancesPage {

    @XmlElement(name = "PerformancePage")
    protected Page performancePage;

    /**
     * Ruft den Wert der performancePage-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link Page }
     *     
     */
    public Page getPerformancePage() {
        return performancePage;
    }

    /**
     * Legt den Wert der performancePage-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link Page }
     *     
     */
    public void setPerformancePage(Page value) {
        this.performancePage = value;
    }

}
