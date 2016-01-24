
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
 *         &lt;element name="UpdatePerformanceResult" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
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
    "updatePerformanceResult"
})
@XmlRootElement(name = "UpdatePerformanceResponse")
public class UpdatePerformanceResponse {

    @XmlElement(name = "UpdatePerformanceResult")
    protected boolean updatePerformanceResult;

    /**
     * Ruft den Wert der updatePerformanceResult-Eigenschaft ab.
     * 
     */
    public boolean isUpdatePerformanceResult() {
        return updatePerformanceResult;
    }

    /**
     * Legt den Wert der updatePerformanceResult-Eigenschaft fest.
     * 
     */
    public void setUpdatePerformanceResult(boolean value) {
        this.updatePerformanceResult = value;
    }

}
