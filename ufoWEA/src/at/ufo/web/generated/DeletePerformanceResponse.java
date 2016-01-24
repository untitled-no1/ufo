
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
 *         &lt;element name="deletePerformanceResult" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
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
    "deletePerformanceResult"
})
@XmlRootElement(name = "deletePerformanceResponse")
public class DeletePerformanceResponse {

    protected boolean deletePerformanceResult;

    /**
     * Ruft den Wert der deletePerformanceResult-Eigenschaft ab.
     * 
     */
    public boolean isDeletePerformanceResult() {
        return deletePerformanceResult;
    }

    /**
     * Legt den Wert der deletePerformanceResult-Eigenschaft fest.
     * 
     */
    public void setDeletePerformanceResult(boolean value) {
        this.deletePerformanceResult = value;
    }

}
