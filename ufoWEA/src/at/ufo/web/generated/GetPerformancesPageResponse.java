
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
 *         &lt;element name="GetPerformancesPageResult" type="{http://ufo.untitled-no1.at/webservice/}ArrayOfPerformance" minOccurs="0"/>
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
    "getPerformancesPageResult"
})
@XmlRootElement(name = "GetPerformancesPageResponse")
public class GetPerformancesPageResponse {

    @XmlElement(name = "GetPerformancesPageResult")
    protected ArrayOfPerformance getPerformancesPageResult;

    /**
     * Ruft den Wert der getPerformancesPageResult-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfPerformance }
     *     
     */
    public ArrayOfPerformance getGetPerformancesPageResult() {
        return getPerformancesPageResult;
    }

    /**
     * Legt den Wert der getPerformancesPageResult-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfPerformance }
     *     
     */
    public void setGetPerformancesPageResult(ArrayOfPerformance value) {
        this.getPerformancesPageResult = value;
    }

}
