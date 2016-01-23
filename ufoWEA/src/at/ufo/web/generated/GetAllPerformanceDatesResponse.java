
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
 *         &lt;element name="GetAllPerformanceDatesResult" type="{http://ufo.untitled-no1.at/webservice/}ArrayOfString" minOccurs="0"/>
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
    "getAllPerformanceDatesResult"
})
@XmlRootElement(name = "GetAllPerformanceDatesResponse")
public class GetAllPerformanceDatesResponse {

    @XmlElement(name = "GetAllPerformanceDatesResult")
    protected ArrayOfString getAllPerformanceDatesResult;

    /**
     * Ruft den Wert der getAllPerformanceDatesResult-Eigenschaft ab.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfString }
     *     
     */
    public ArrayOfString getGetAllPerformanceDatesResult() {
        return getAllPerformanceDatesResult;
    }

    /**
     * Legt den Wert der getAllPerformanceDatesResult-Eigenschaft fest.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfString }
     *     
     */
    public void setGetAllPerformanceDatesResult(ArrayOfString value) {
        this.getAllPerformanceDatesResult = value;
    }

}
