
package at.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java-Klasse für Page complex type.
 * 
 * <p>Das folgende Schemafragment gibt den erwarteten Content an, der in dieser Klasse enthalten ist.
 * 
 * <pre>
 * &lt;complexType name="Page">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="Offset" type="{http://www.w3.org/2001/XMLSchema}int"/>
 *         &lt;element name="Size" type="{http://www.w3.org/2001/XMLSchema}int"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Page", propOrder = {
    "offset",
    "size"
})
public class Page {

    @XmlElement(name = "Offset")
    protected int offset;
    @XmlElement(name = "Size")
    protected int size;

    /**
     * Ruft den Wert der offset-Eigenschaft ab.
     * 
     */
    public int getOffset() {
        return offset;
    }

    /**
     * Legt den Wert der offset-Eigenschaft fest.
     * 
     */
    public void setOffset(int value) {
        this.offset = value;
    }

    /**
     * Ruft den Wert der size-Eigenschaft ab.
     * 
     */
    public int getSize() {
        return size;
    }

    /**
     * Legt den Wert der size-Eigenschaft fest.
     * 
     */
    public void setSize(int value) {
        this.size = value;
    }

}
